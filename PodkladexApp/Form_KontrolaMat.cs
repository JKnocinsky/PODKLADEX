using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodkladexApp
{
    public partial class Form_KontrolaMat : Form
    {
        PodkladexContext _context;
        public Form_KontrolaMat(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;
        }
    }
}
