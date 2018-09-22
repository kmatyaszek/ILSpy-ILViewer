using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal class EventILDisassembler : ILDisassemblerBase
	{
		internal override string Disassemble(IEntity entity)
		{
			EventDefinitionHandle handle = (EventDefinitionHandle)entity.MetadataToken;
			_reflectionDisassembler.DisassembleEvent(entity.ParentModule.PEFile, handle);
			return _textOutput.ToString();
		}
	}
}
