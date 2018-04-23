Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Drawing


Namespace WindowsApplication3
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Orders' table. You can move, or remove it, as needed.
			Me.ordersTableAdapter.Fill(Me.nwindDataSet.Orders)
		End Sub

		Private Sub OnGridViewShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles gridView1.ShownEditor
			Dim view As GridView = TryCast(sender, GridView)
			If TypeOf view.ActiveEditor Is DateEdit Then
				dateEditExtender1.SetEnlargeDatesOnMouseHover(TryCast(view.ActiveEditor, DateEdit), checkEdit1.Checked)
			End If
		End Sub

		Private Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit1.CheckedChanged
			dateEditExtender1.SetEnlargeDatesOnMouseHover(dateEdit1, (TryCast(sender, CheckEdit)).Checked)
		End Sub
	End Class
End Namespace
