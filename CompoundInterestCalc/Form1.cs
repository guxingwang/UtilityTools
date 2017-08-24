using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompoundInterestCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal money = this.txtSourceMoney.Text.ToDecimal();//本金
            decimal rate = this.txtRate.Text.ToDecimal() / 100;//利率
            int count = this.txtCount.Text.ToInt();//计算次数

            decimal result = money;//总收益率

            for (int i = 0; i < count;i++ )
            {
                result = result * (1 + rate);
            }

            this.txtResult.Text = result.ToString("f2");
            this.txtInterest.Text = (result - money).ToString("f2");//计算总利息
            this.txtYieldRate.Text = string.Format("{0:P}", (result - money) / money);
            Clipboard.SetText(this.txtResult.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtRate.Text = (this.txtMoneyMore.Text.ToDecimal() * 100 / this.txtSourceMoney.Text.ToDecimal()).ToString("f8");
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// 扩展string方法，转换为Decimal类型数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            else
            {
                decimal result = 0;
                decimal.TryParse(s, out result);
                return result;
            }
        }

        /// <summary>
        /// 扩展string方法，转换为int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            else
            {
                int result = 0;
                int.TryParse(s.Trim(), out result);
                return result;
            }
        }


    }

}
