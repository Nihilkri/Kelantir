namespace Kelantir {
	partial class Kelantir {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.Location = new System.Drawing.Point(12, 12);
			this.tree.Name = "tree";
			this.tree.Size = new System.Drawing.Size(560, 938);
			this.tree.TabIndex = 0;
			// 
			// Kelantir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 962);
			this.Controls.Add(this.tree);
			this.Name = "Kelantir";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kelan\'tir";
			this.Load += new System.EventHandler(this.Kelantir_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tree;
	}
}

