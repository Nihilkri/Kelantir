using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NihilKri;

namespace Kelantir {
	public partial class Kelantir : Form {
		#region Constants
		public const double PI = 3.14159265358979323846264338327950288419716939937510; // Diameter to Circumference
		public const double AR = PI / 180.0; // Degrees to Radians
		public const int    c  = 299792458; // Speed of light, in m/s
		public const double G  = 6.673848e-11; // Gravitational Constant, in m3/kg/s2 or N(m/kg)2
		public const double h  = 6.6260695729e-34; // Planck Constant, in J*s or N*m*s or kg*m2/s
		public const double hb = h / 2 / PI; // Reduced Planck Constant, in J*s or N*m*s or kg*m2/s
		public const double kB = 1.380648813e-23; // Bolzmann's Constant, in J/K
		public const double SB = 5.67037321e-8; // Stefan-Boltzmann Constant, in W/m2/K4 or J/s/m2/K4

		#region Units
		public static readonly double Sk = Math.Pow(h*G/Math.Pow(c,3.0),0.5)*Math.Pow(16.0,28.0); // I Silak = Sk Meters; Lp * 16^28
		public static readonly double Sl = 4.0/3.0*PI*Math.Pow(Sk/16.0,3.0); // 1 Sirol = Sl m3; 4/3*pi*(m/Sk/16)^3
		public static readonly double Ms = Sl*1000.0; // 1 Misol = Ms kg; (mL/Sl) * ((1 kg) / (1 mL))
		public static readonly double Kk = Sk*Math.Pow(16.0,8.0); // 1 Kelik = Kk meters; 1 m / Sk Silak * 16^8
		public static readonly double Kr = Kk / c; // 1 Karos = Kr seconds; (m/Kk) * ((1 s) / (c m))
		public static readonly double Mk = 205.7495/256.0; // 1 Mok'tir = Mk Kelvin; 205.7495 K / 256 Mk

		public static readonly double Fc = c / Sk; // Speed of light, in Sk/s
		public static readonly double FG = G / Sk / Sk / Sk * Ms; //Gravitational Constant, in Sk3/Ms/s2
		public static readonly double Fh = h / Ms / Sk / Sk; //Planck Constant, in Ms*Sk2/s
		public static readonly double FkB = kB / Ms / Sk / Sk * Mk; // Bolzmann's Constant, in J/K
		public static readonly double FSB = SB / Ms * Mk * Mk * Mk * Mk; // Stefan-Boltzmann Constant, in W/m2/K4 or J/s/m2/K4

		public static readonly double Sc = Fc * Kr; // Speed of light, in Sk/Kr
		public static readonly double SG = FG * Kr * Kr; //Gravitational Constant, in Sk3/Ms/Kr2
		public static readonly double Sh = Fh * Kr; //Planck Constant, in Ms*Sk2/Kr
		public static readonly double SkB = FkB * Kr * Kr; // Bolzmann's Constant, in J/K
		public static readonly double SSB = FSB * Kr * Kr * Kr; // Stefan-Boltzmann Constant, in W/m2/K4 or J/s/m2/K4

		public static readonly double In = 0.0254; // In meters = 1 inch
		public static readonly double Ft = In*12.0; // Ft meters = 1 foot
		public static readonly double Cm = 0.01; // cm meters = 1 centimeter
		public static readonly double mL = Math.Pow(Cm,3.0); // 1 mL = 1 cm3; mL meter3s = 1 centimeter3
		public static readonly double In3 = Math.Pow(In,3.0); // In3 meter3s = 1 inch3
		public static readonly double Gal = 231.0*In3; // Gal meter3s = 1 gallon
		public static readonly double Foz = Gal/128.0; // Foz meter3s = 1 fluid ounce
		public static readonly double Lb = 0.45359237; // Lb kilograms = 1 pound
		public static readonly double Oz = Lb/16.0; // Oz grams = 1 ounce
		public static readonly double Km = 1000.0; // Km meters = 1 kilometer
		public static readonly double Mi = Ft*5280.0; // Mi meters = 1 mile
		public static readonly double Mn = 60.0; // Mn seconds = 1 minute
		public static readonly double Hr = Mn*60.0; // Hr seconds = 1 hour
		public static readonly double Day = Hr*24.0; // Day seconds = 1 earth day
	
		#endregion Units

		#endregion Constants
		public Kelantir() {InitializeComponent();}
		private void Kelantir_Load(object sender, EventArgs e) {

			UnitDump();

			//tree.Nodes[0].Expand();
			tree.ExpandAll();
			foreach(TreeNode n in tree.Nodes[0].Nodes) n.Collapse(true);
			tree.Nodes[0].LastNode.ExpandAll();
			//tree.Nodes[tree.GetNodeCount(false)].Expand();

		}

		double Fg(double m1, double m2, double r) { return G * ((m1 * m2) / (r * r)); }
		string fmt(double n) { return n.ToString("E17"); }
		private void UnitDump() {
			TreeNode a = new TreeNode("Units");
			tree.Nodes.Add(a);
			a = a.Nodes.Add("Constants");
			a = a.Nodes.Add("Meter, Kilogram, Second");
			a.Nodes.Add(" c   " + fmt(c));
			a.Nodes.Add(" G   " + fmt(G));
			a.Nodes.Add(" h   " + fmt(h));
			a.Nodes.Add("kB   " + fmt(kB));
			a.Nodes.Add("SB   " + fmt(SB));
			a.Nodes.Add("SB   " + fmt((2 * Math.Pow(PI, 5) * Math.Pow(kB, 4)) / (15 * h * h * h * c * c)));
			a = a.Parent.Nodes.Add("Silak, Misol, Karos");
			a.Nodes.Add(" c   " + fmt(Sc));
			a.Nodes.Add(" G   " + fmt(SG));
			a.Nodes.Add(" h   " + fmt(Sh));
			a.Nodes.Add("kB   " + fmt(SkB));
			a.Nodes.Add("SB   " + fmt(SSB));
			a.Nodes.Add("SB   " + fmt((2 * Math.Pow(PI, 5) * Math.Pow(SkB, 4)) / (15 * Sh * Sh * Sh * Sc * Sc)));
			a = a.Parent.Nodes.Add("Silak, Misol, Second");
			a.Nodes.Add(" c   " + fmt(Fc));
			a.Nodes.Add(" G   " + fmt(FG));
			a.Nodes.Add(" h   " + fmt(Fh));
			a.Nodes.Add("kB   " + fmt(FkB));
			a.Nodes.Add("SB   " + fmt(FSB));
			a.Nodes.Add("SB   " + fmt((2 * Math.Pow(PI, 5) * Math.Pow(FkB, 4)) / (15 * Fh * Fh * Fh * Fc * Fc)));

			a = a.Parent.Parent.Nodes.Add("Hiserati Units");
			a = a.Nodes.Add("Silak: 16^28*sqrt(2*pi) Planck Lengths");
			a.Nodes.Add(" m/Sk  " + fmt(Sk / 1.0));
			a.Nodes.Add("Sk/m   " + fmt(1.0 / Sk));
			a.Nodes.Add("in/Sk  " + fmt(Sk / In));
			a.Nodes.Add("Sk/in  " + fmt(In / Sk));
			a.Nodes.Add("ft/Sk  " + fmt(Sk / Ft));
			a.Nodes.Add("Sk/ft  " + fmt(Ft / Sk));
			a = a.Parent.Nodes.Add("Misol: Mass of a Sirol of water");
			a.Nodes.Add(" g/Ms  " + fmt(Ms * 1000.0));
			a.Nodes.Add("Ms/g   " + fmt(1.0 / Ms / 1000.0));
			a.Nodes.Add("oz/Ms  " + fmt(Ms * 1.0 / Oz));
			a.Nodes.Add("Ms/oz  " + fmt(Oz / Ms));
			a.Nodes.Add("kg/Ms  " + fmt(Ms / 1.0));
			a.Nodes.Add("Ms/kg  " + fmt(1.0 / Ms));
			a.Nodes.Add("lb/Ms  " + fmt(Ms / Lb));
			a.Nodes.Add("Ms/lb  " + fmt(Lb / Ms));
			a = a.Parent.Nodes.Add("Kelik: 16^8 Silak'na");
			a.Nodes.Add(" Gm/Kk  " + fmt(Kk / Km / 1e6));
			a.Nodes.Add(" Kk/Gm  " + fmt(Km / Kk * 1e6));
			a.Nodes.Add("MMi/Kk  " + fmt(Kk / Mi / 1e6));
			a.Nodes.Add(" Kk/MMi " + fmt(Mi / Kk * 1e6));
			a = a.Parent.Nodes.Add("Karos: Time it takes light to cross 1 Kelik");
			a.Nodes.Add(" s/Kr  " + fmt(Kr / 1.0));
			a.Nodes.Add("Kr/s   " + fmt(1.0 / Kr));
			a.Nodes.Add("Mn/Kr  " + fmt(Kr / Mn));
			a.Nodes.Add("Kr/Mn  " + fmt(Mn / Kr));
			//a.Nodes.Add("  Hr/Kr  " + fmt(Kr/Hr));
			//a.Nodes.Add("  Kr/Hr  " + fmt(Hr/Kr));
			//UnitRationalizer("Kr", "s", 1. / Kr);
			a = a.Parent.Nodes.Add("Mok'tir: 1/256 of the temperature between freezing and boiling of water");
			a.Nodes.Add(" K/Mk  " + fmt(Mk / 1.0));
			a.Nodes.Add("Mk/K   " + fmt(1.0 / Mk));
			a.Nodes.Add(" F/Mk  " + fmt(Mk / 1.8));
			a.Nodes.Add("Mk/F   " + fmt(1.8 / Mk));
			//UnitRationalizer("Mk", "K", 1. / Mk);
			a = a.Parent.Nodes.Add("Velocity: Sk/Kr: ");
			a.Nodes.Add("  m/s / Sk/Kr  " + fmt(Kr / Sk / 1.0));
			a.Nodes.Add("Sk/Kr / m/s    " + fmt(1.0 / Kr * Sk));
			//UnitRationalizer("Sk/Kr", "m/s", 1. / Kr*Sk);
			a = a.Parent.Nodes.Add("Acceleration: Sk/Kr2: ");
			a.Nodes.Add("  m/s2 / Sk/Kr2 " + fmt(Kr * Kr / Sk / 1.0));
			a.Nodes.Add("Sk/Kr2 / m/s2   " + fmt(1.0 / Kr / Kr * Sk));
			//UnitRationalizer("Sk/Kr2", "m/s2", 1.0 / Kr/Kr*Sk);
			a = a.Parent.Nodes.Add("Force: Ms*Sk/Kr2: ");
			a.Nodes.Add("  N / Ms*Sk/Kr2 " + fmt(Kr * Kr / Sk / Ms / 1.0));
			a.Nodes.Add("Ms*Sk/Kr2 / N   " + fmt(1.0 / Kr / Kr * Sk * Ms));
			a = a.Parent.Nodes.Add("Pressure: Ms/Sk/Kr2: ");
			a.Nodes.Add(" Pa / Ms/Sk/Kr2 " + fmt(Kr * Kr * Sk / Ms / 1.0));
			a.Nodes.Add("Ms/Sk/Kr2 / Pa  " + fmt(1.0 / Kr / Kr / Sk * Ms));
			a = a.Parent.Nodes.Add("Work: Ms*Sk2/Kr2: ");
			a.Nodes.Add(" J / Ms*Sk2/Kr2 " + fmt(Kr * Kr / Sk / Sk / Ms / 1.0));
			a.Nodes.Add("Ms*Sk2/Kr2 / J  " + fmt(1.0 / Kr / Kr * Sk * Sk * Ms));
			a = a.Parent.Nodes.Add("Power: Ms*Sk2/Kr3: ");
			a.Nodes.Add(" W / Ms*Sk2/Kr3 " + fmt(Kr * Kr * Kr / Sk / Sk / Ms / 1.0));
			a.Nodes.Add("Ms*Sk2/Kr3 / W  " + fmt(1.0 / Kr / Kr / Kr * Sk * Sk * Ms));
			a = a.Parent.Nodes.Add("Density: Ms/Sk3: ");
			a.Nodes.Add(" kg/m3 / Ms/Sk3 " + fmt(Sk * Sk * Sk / Ms / 1.0));
			a.Nodes.Add("Ms/Sk3 / kg/m3  " + fmt(1.0 / Sk / Sk / Sk * Ms));

		}
		private void CalcSerati() {



		}
		private void CalcWorlds() {



		}

		private void tree_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); break;

				default: break;
			}


		}

	}
}
