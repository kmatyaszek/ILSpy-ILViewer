using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal class FieldILDisassembler : ILDisassemblerBase
	{
		internal override string Disassemble(IEntity entity)
		{
			FieldDefinitionHandle handle = (FieldDefinitionHandle)entity.MetadataToken;
			_reflectionDisassembler.DisassembleField(entity.ParentModule.PEFile, handle);
			return _textOutput.ToString();
		}
	}
}