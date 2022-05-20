using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class StructClass : Component
    { 
        
        public struct History
        {
            public int ball;
            public int trueOt;
            public int falseOt;
            public Boolean check;
            public History()
          {
                ball = 0;
                trueOt = 0; 
                falseOt = 0;
                check = false;
          }
        }
        public struct Geography
        {
            public int ball;
            public int trueOt;
            public int falseOt;
            public Boolean check;
            public Geography()
            {
                ball = 0;
                trueOt = 0;
                falseOt = 0;
                check = false;
            }
        }
        public struct Liter
        {
            public int ball;
            public int trueOt;
            public int falseOt;
            public Boolean check;
            public Liter()
            {
                ball = 0;
                trueOt = 0;
                falseOt = 0;
                check = false;
            }
        }
        public StructClass()
        {
            InitializeComponent();
        }

        public StructClass(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
       
    }
}
