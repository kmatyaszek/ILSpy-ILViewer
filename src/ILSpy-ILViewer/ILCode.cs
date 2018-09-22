using System;
using ICSharpCode.Decompiler.TypeSystem;
using ILSpy_ILViewer.Disassembler;

namespace ILSpy_ILViewer
{
	internal class ILCode
	{
		internal static string Get(IEntity entity)
		{
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			ILDisassemblerBase disassembler = MakeDisassembler(entity); 
			return disassembler.Disassemble(entity);
		}

		private static ILDisassemblerBase MakeDisassembler(IEntity entity)
		{
			ILDisassemblerBase disassembler;
			switch (entity) {
				case ITypeDefinition td:
					disassembler = new TypeILDisassembler();
					break;
				case IField fd:
					disassembler = new FieldILDisassembler();
					break;
				case IMethod md:
					disassembler = new MethodILDisassembler();
					break;
				case IProperty pd:
					disassembler = new PropertyILDisassembler();
					break;
				case IEvent ed:
					disassembler = new EventILDisassembler();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(entity), $"Entity {entity.GetType().FullName} is not supported.");
			}

			return disassembler;
		}
	}	
}