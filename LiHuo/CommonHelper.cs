using FGTran;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public  class CommonHelper
    {
        public static Hashtable GetDataGridViewColumns(DataGridView dgv)
        {
            Hashtable ht = new Hashtable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                ht[column.DataPropertyName] = column.HeaderText;
            }
            return ht;
        }

        public static void AddColumn(DataGridView dgv,string ColumnName,string DataName,bool readOnly = true,int width=100, DataGridViewColumnSortMode sortAble = DataGridViewColumnSortMode.NotSortable)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = DataName;
            column.HeaderText = ColumnName;
            column.ReadOnly = readOnly;
            column.Width = width;
            column.SortMode = sortAble;
            dgv.Columns.Add(column);
        }
    }
}
