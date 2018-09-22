using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal class PropertyILDisassembler : ILDisassemblerBase
	{
		internal override string Disassemble(IEntity entity)
		{
			PropertyDefinitionHandle handle = (PropertyDefinitionHandle)entity.MetadataToken;
			_reflectionDisassembler.DisassembleProperty(entity.ParentModule.PEFile, handle);
			return _textOutput.ToString();
		}
	}
}