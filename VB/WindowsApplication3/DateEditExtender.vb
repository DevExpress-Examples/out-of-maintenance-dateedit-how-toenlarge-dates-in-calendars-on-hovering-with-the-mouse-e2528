Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors.Controls
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Calendar
Imports System.Drawing

Namespace WindowsApplication3

  <ProvideProperty("EnlargeDatesOnMouseHover", GetType(DateEdit))> _
  Public Class DateEditExtender
	  Inherits Component
	  Implements IExtenderProvider

	Private enlargeDatesOnMouseHover As Boolean = False
	Private hotTrackDate As DateTime = DateTime.MinValue

	Public Function GetEnlargeDatesOnMouseHover(ByVal control As DateEdit) As Boolean
		Return enlargeDatesOnMouseHover
	End Function

	Public Sub SetEnlargeDatesOnMouseHover(ByVal control As DateEdit, ByVal value As Boolean)
		enlargeDatesOnMouseHover = value
		If enlargeDatesOnMouseHover Then
			control.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
			SubscribeToDateEditEvents(control)
		Else
			UnsubscribeFromDateEditEvents(control)
		End If
	End Sub

	  Private Sub SubscribeToDateEditEvents(ByVal control As DateEdit)
		  AddHandler control.Popup, AddressOf OnPopup
		  AddHandler control.CloseUp, AddressOf OnCloseUp
	  End Sub

	  Private Sub UnsubscribeFromDateEditEvents(ByVal control As DateEdit)
		  RemoveHandler control.Popup, AddressOf OnPopup
		  RemoveHandler control.CloseUp, AddressOf OnCloseUp
	  End Sub

	  Private Sub OnPopup(ByVal sender As Object, ByVal e As EventArgs)
		  SubscribeToCalendarEvents(GetCalendar(sender))
	  End Sub

	  Private Sub OnCloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs)
		  UnsubscribeFromCalendarEvents(GetCalendar(sender))
	  End Sub

	  Private Function GetCalendar(ByVal sender As Object) As DateEditCalendar
		  Dim form As PopupDateEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupDateEditForm)
		  Return form.Calendar
	  End Function

	  Private Sub SubscribeToCalendarEvents(ByVal calendar As DateEditCalendar)
		  AddHandler calendar.MouseMove, AddressOf OnMouseMove
		  AddHandler calendar.CustomDrawDayNumberCell, AddressOf OnCustomDrawDayNumberCell
	  End Sub

	  Private Sub UnsubscribeFromCalendarEvents(ByVal calendar As DateEditCalendar)
		  RemoveHandler calendar.MouseMove, AddressOf OnMouseMove
		  RemoveHandler calendar.CustomDrawDayNumberCell, AddressOf OnCustomDrawDayNumberCell
	  End Sub

	  Private Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
		  Dim calendar As DateEditCalendar = TryCast(sender, DateEditCalendar)
		  Dim hitInfo As CalendarHitInfo = calendar.GetHitInfo(e)
		  If hitInfo.InfoType = CalendarHitInfoType.Item Then
			  hotTrackDate = hitInfo.HitDate
		  End If
	  End Sub

	  Private Sub OnCustomDrawDayNumberCell(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)
		  If IsHotTrackDate(e.Date) Then
			  e.Style.Font = New System.Drawing.Font(e.Style.Font.FontFamily, e.Style.Font.Size + CSng(1.25))
		  End If
	  End Sub

	  Private Function IsHotTrackDate(ByVal [date] As DateTime) As Boolean
		  Return hotTrackDate = [date]
	  End Function

	#Region "IExtenderProvider Members"

	  Public Function CanExtend(ByVal control As Object) As Boolean Implements IExtenderProvider.CanExtend
		  Return TypeOf control Is DateEdit
	  End Function
	#End Region
  End Class
End Namespace

