using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Calendar;
using System.Drawing;

namespace WindowsApplication3 {

  [ProvideProperty("EnlargeDatesOnMouseHover", typeof(DateEdit))]
  public class DateEditExtender : Component, IExtenderProvider {

    bool enlargeDatesOnMouseHover = false;
    DateTime hotTrackDate = DateTime.MinValue;

    public bool GetEnlargeDatesOnMouseHover(DateEdit control) {
        return enlargeDatesOnMouseHover;
    }

    public void SetEnlargeDatesOnMouseHover(DateEdit control, bool value) {
        enlargeDatesOnMouseHover = value;
        if(enlargeDatesOnMouseHover) {
            control.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            SubscribeToDateEditEvents(control);
        }
        else UnsubscribeFromDateEditEvents(control);
    }

      private void SubscribeToDateEditEvents(DateEdit control) {
          control.Popup += OnPopup;
          control.CloseUp += OnCloseUp;
      }

      private void UnsubscribeFromDateEditEvents(DateEdit control) {
          control.Popup -= OnPopup;
          control.CloseUp -= OnCloseUp;
      }

      void OnPopup(object sender, EventArgs e) {
          SubscribeToCalendarEvents(GetCalendar(sender));
      }

      void OnCloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e) {
          UnsubscribeFromCalendarEvents(GetCalendar(sender));
      }

      private DateEditCalendar GetCalendar(object sender) {
          PopupDateEditForm form = (sender as IPopupControl).PopupWindow as PopupDateEditForm;
          return form.Calendar;
      }

      private void SubscribeToCalendarEvents(DateEditCalendar calendar) {
          calendar.MouseMove += OnMouseMove;
          calendar.CustomDrawDayNumberCell += OnCustomDrawDayNumberCell;
      }

      private void UnsubscribeFromCalendarEvents(DateEditCalendar calendar) {
          calendar.MouseMove -= OnMouseMove;
          calendar.CustomDrawDayNumberCell -= OnCustomDrawDayNumberCell;
      }

      void OnMouseMove(object sender, MouseEventArgs e) {
          DateEditCalendar calendar = sender as DateEditCalendar;
          CalendarHitInfo hitInfo = calendar.GetHitInfo(e);
          if(hitInfo.InfoType == CalendarHitInfoType.Item) 
              hotTrackDate = hitInfo.HitDate;
      }

      void OnCustomDrawDayNumberCell(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e) {
          if(IsHotTrackDate(e.Date))
              e.Style.Font = new System.Drawing.Font(e.Style.Font.FontFamily, e.Style.Font.Size + (float)1.25);
      }

      private bool IsHotTrackDate(DateTime date) {
          return hotTrackDate == date;
      }

    #region IExtenderProvider Members

      public bool CanExtend(object control)
    {
          return control is DateEdit;
    }
    #endregion
  }
}

