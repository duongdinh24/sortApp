using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quickSortapp
{
    class CodeC
    {
        public void quicksort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
			// Truyền code C quickSort
			list_Code.Items.Add("void quickSort(int a[], int low, int high)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	if (low >= high)");
			list_Code.Items.Add("		return;");
			list_Code.Items.Add("	else");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		int pivot = a[high];");
			list_Code.Items.Add("		int right = high - 1;");
			list_Code.Items.Add("		int left = low;");
			list_Code.Items.Add("		while (true)");
			list_Code.Items.Add("		{");

			// Nếu là sắp xếp tăng
			if (tang) 
            {
				list_Code.Items.Add("			while (a[left] < pivot && left <= right) left++;");
				list_Code.Items.Add("			while (a[right] > pivot && right >= left) right--;");
			}

			// Nếu là sắp xếp giảm
            else
            {
				list_Code.Items.Add("			while (a[left] > pivot && left <= right) left++;");
				list_Code.Items.Add("			while (a[right] < pivot && right >= left) right--;");
			}
			list_Code.Items.Add("			if (left >= right)");
			list_Code.Items.Add("				break;");
			list_Code.Items.Add("			swap(a[left], a[right]);");
			list_Code.Items.Add("			left++;");
			list_Code.Items.Add("			right--;");
			list_Code.Items.Add("		}");
			list_Code.Items.Add("		swap(a[left], a[high]);");
			list_Code.Items.Add("		quickSort(a, low, left - 1);");
			list_Code.Items.Add("		quickSort(a, left + 1, high);");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
			/// Hàm swap
			list_Code.Items.Add("  void Swap(int &a,int &b)  {");
			list_Code.Items.Add("           int temp = a;");
			list_Code.Items.Add("            a = b;");
			list_Code.Items.Add("            b=temp;");
			list_Code.Items.Add(" }");
		}
    }
}
