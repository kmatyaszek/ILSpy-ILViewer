using System.Threading;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Disassembler;
using ICSharpCode.Decompiler.TypeSystem;

namespace ILSpy_ILViewer.Disassembler
{
	internal abstract class ILDisassemblerBase
	{
		protected ReflectionDisassembler _reflectionDisassembler;
		protected ITextOutput _textOutput;

		internal ILDisassemblerBase()
		{
			_textOutput = new PlainTextOutput();
			_reflectionDisassembler = new ReflectionDisassembler(_textOutput, CancellationToken.None);			
		}

		internal abstract string Disassemble(IEntity entity);
	}
}