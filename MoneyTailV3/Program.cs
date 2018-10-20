﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTailV3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseHelpers.GetMockTransactions();
            DatabaseHelpers.GetMockTransactions();
            DatabaseHelpers.GetMockTransactions();
            DatabaseHelpers.GetMockTransactions();
            DatabaseHelpers.GetMockTransactions();

            DatabaseHelpers.GetMockBudgets();
            DatabaseHelpers.GetMockBudgets();
            DatabaseHelpers.GetMockBudgets();
            DatabaseHelpers.GetMockBudgets();
            DatabaseHelpers.GetMockBudgets();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDashboard());

        }
    }
}
