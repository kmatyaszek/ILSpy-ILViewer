using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal class TypeILDisassembler : ILDisassemblerBase
	{
		internal override string Disassemble(IEntity entity)
		{
			TypeDefinitionHandle handle = (TypeDefinitionHandle)entity.MetadataToken;
			_reflectionDisassembler.DisassembleType(entity.ParentModule.PEFile, handle);
			return _textOutput.ToString();
		}
	}
}