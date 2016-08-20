using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendRight {
	public partial class FormRisks : Form {
		private List<Tuple<string, string, string>> _lstRisks;
		public FormRisks(List<Tuple<string, string, string>> lstRisks) {
			InitializeComponent();
			this._lstRisks = lstRisks;
		}

		private void FormRisks_Load(object sender, EventArgs e) {
			string[] arrDigits = new string [10] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

			List<string> lstRiskHtml = new List<string>();
			foreach (var tuple in this._lstRisks) {
				string s = $@"
					<li>
						<span class='title'>{tuple.Item1}</span>:
						<span class='violating'>{tuple.Item2}</span>
						(<span class='comment'>{tuple.Item3}</span>)
					</li>
				";
				lstRiskHtml.Add(s);
			}

			string content = string.Join("\r\n", lstRiskHtml);
			int numRisks = lstRiskHtml.Count;
			string sNumRisks = "";
			if (numRisks == 1) {
				sNumRisks = "One risk";
			}
			else if (numRisks < arrDigits.Length) {
				sNumRisks = $"{arrDigits[numRisks]} risks";
			}
			else {
				sNumRisks = $"{numRisks} risks";
			}

			string html = $@"
				<html>
					<head>
						<style>
							body {{ font-family: arial; }}
							div.heading {{ font-size: 27px; font-weight: bold; color: #001BB7; }}
							span.title {{ background-color: yellow; }}
							span.violating {{ color: red; }}
							span.comment {{ color: #777777; }}
						</style>
					</head>
					<body>
						<div class='heading'>
							{sNumRisks} observed:
						</div>
						<div>
							<ol>
								{content}
							</ol>
						</div>
					</body>
				</html>
			";

			if (Screen.PrimaryScreen.Bounds.Width >= 1400) {
				this.Size = new Size(1330, this.Size.Height);
			}

			this.html.Text = html;
		}
	}
}
