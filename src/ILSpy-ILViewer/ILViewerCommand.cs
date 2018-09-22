using System.Linq;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.ILSpy;
using ICSharpCode.ILSpy.TreeNodes;

namespace ILSpy_ILViewer
{
	[ExportContextMenuEntry(Header = "Show IL code", Category = "ILViewer", Order = 50)]
	internal sealed class ILViewerCommand : SimpleCommand, IContextMenuEntry
	{
		public bool IsVisible(TextViewContext context)
		{
			if (context.SelectedTreeNodes != null && context.SelectedTreeNodes.All(n => n.Parent.IsRoot))
				return false;			
			return context.SelectedTreeNodes.All(n => n is IMemberTreeNode) && context.SelectedTreeNodes.Count() == 1;
		}

		public bool IsEnabled(TextViewContext context)
		{		
			foreach (IMemberTreeNode node in context.SelectedTreeNodes) {
				if (!IsValidReference(node.Member))
					return false;
			}

			return true;
		}

		bool IsValidReference(object reference)
		{
			return reference is IEntity;
		}

		public void Execute(TextViewContext context)
		{
			if (context.SelectedTreeNodes != null) {
				IMemberTreeNode node = context.SelectedTreeNodes.First() as IMemberTreeNode;

				ILViewerView win = new ILViewerView(node, ILCode.Get(node.Member));
				win.ShowDialog();
			}
		}

		public override bool CanExecute(object parameter)
		{
			return MainWindow.Instance.SelectedNodes.All(n => n is IMemberTreeNode) && MainWindow.Instance.SelectedNodes.Count() == 1; ;
		}

		public override void Execute(object parameter)
		{
			IMemberTreeNode node = MainWindow.Instance.SelectedNodes.First() as IMemberTreeNode;

			ILViewerView win = new ILViewerView(node, ILCode.Get(node.Member));
			win.ShowDialog();
		}
	}
}
