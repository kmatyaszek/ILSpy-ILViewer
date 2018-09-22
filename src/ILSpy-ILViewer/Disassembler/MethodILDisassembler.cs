using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal class MethodILDisassembler : ILDisassemblerBase
	{
		internal override string Disassemble(IEntity entity)
		{
			MethodDefinitionHandle handle = (MethodDefinitionHandle)entity.MetadataToken;
			_reflectionDisassembler.DisassembleMethod(entity.ParentModule.PEFile, handle);
			return _textOutput.ToString();
		}
	}
}