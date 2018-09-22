using System;
using System.Windows;
using ICSharpCode.ILSpy.TreeNodes;

namespace ILSpy_ILViewer
{
	/// <summary>
	/// Interaction logic for ILViewerView.xaml
	/// </summary>
	public partial class ILViewerView : Window
    {
        public ILViewerView(IMemberTreeNode node, string ilCode)
        {
            InitializeComponent();

			Title = $"IL code: {node.Member.FullName}";
			tbIlCode.Text = ilCode;
		}
	}
}
