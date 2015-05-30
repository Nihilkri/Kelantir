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
		public const double Sk = Math.Pow(h*G/Math.Pow(c,3.0),0.5)*Math.Pow(16.0,28.0); // I Silak = Sk Meters; Lp * 16^28
		public const double Sl = 4.0/3.0*PI*Math.Pow(Sk/16.0,3.0); // 1 Sirol = Sl m3; 4/3*pi*(m/Sk/16)^3
		public const double Ms = Sl*1000.0; // 1 Misol = Ms kg; (mL/Sl) * ((1 kg) / (1 mL))
		public const double Kk = Sk*Math.Pow(16.0,8.0); // 1 Kelik = Kk meters; 1 m / Sk Silak * 16^8
		public const double Kr = Kk / c; // 1 Karos = Kr seconds; (m/Kk) * ((1 s) / (c m))
		public const double Mk = 205.7495/256.0; // 1 Mok'tir = Mk Kelvin; 205.7495 K / 256 Mk

		public const double Fc = c / Sk; // Speed of light, in Sk/s
		public const double FG = G / Sk / Sk / Sk * Ms; //Gravitational Constant, in Sk3/Ms/s2
		public const double Fh = h / Ms / Sk / Sk; //Planck Constant, in Ms*Sk2/s
		public const double FkB = kB / Ms / Sk / Sk * Mk; // Bolzmann's Constant, in J/K
		public const double FSB = SB / Ms * Mk * Mk * Mk * Mk; // Stefan-Boltzmann Constant, in W/m2/K4 or J/s/m2/K4

		public const double Sc = Fc * Kr; // Speed of light, in Sk/Kr
		public const double SG = FG * Kr * Kr; //Gravitational Constant, in Sk3/Ms/Kr2
		public const double Sh = Fh * Kr; //Planck Constant, in Ms*Sk2/Kr
		public const double SkB = FkB * Kr * Kr; // Bolzmann's Constant, in J/K
		public const double SSB = FSB * Kr * Kr * Kr; // Stefan-Boltzmann Constant, in W/m2/K4 or J/s/m2/K4

		static const double In = 0.0254; // In meters = 1 inch
		static const double Ft = In*12.0; // Ft meters = 1 foot
		static const double Cm = 0.01; // cm meters = 1 centimeter
		static const double mL = Math.Pow(Cm,3.0); // 1 mL = 1 cm3; mL meter3s = 1 centimeter3
		static const double In3 = Math.Pow(In,3.0); // In3 meter3s = 1 inch3
		static const double Gal = 231.0*In3; // Gal meter3s = 1 gallon
		static const double Foz = Gal/128.0; // Foz meter3s = 1 fluid ounce
		static const double Lb = 0.45359237; // Lb kilograms = 1 pound
		static const double Oz = Lb/16.0; // Oz grams = 1 ounce
		static const double Km = 1000.0; // Km meters = 1 kilometer
		static const double Mi = Ft*5280.0; // Mi meters = 1 mile
		static const double Mn = 60.0; // Mn seconds = 1 minute
		static const double Hr = Mn*60.0; // Hr seconds = 1 hour
		static const double Day = Hr*24.0; // Day seconds = 1 earth day
	
		#endregion Units

		#endregion Constants
		public Kelantir() {InitializeComponent();}
		private void Kelantir_Load(object sender, EventArgs e) {

		}
	}
}
