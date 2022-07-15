using System;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace Randomizer
{
    public partial class Main : Form
    {
        private string original = "";
        private string output = "";

        public Main()
        {
            InitializeComponent();
        }

        private uint BKDR(string str)
        {
            uint seed = 131, hash = 0;

            for (int i = 0; i < str.Length; i++)
                hash = (hash * seed) + ((byte)str[(int)i]);

            return hash;
        }

        private void SelectBase_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                original = dialog.FileName;
                BaseStatus.Text = $"Base Directory: {original}";
            }
        }

        private void SelectGame_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                output = dialog.FileName;
                GameStatus.Text = $"Game Directory: {output}";
            }
        }

        private void RegenerateSeed_Click(object sender, EventArgs e)
        {
            SeedInput.Text = new Random().Next().ToString();
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            if (original == "")
                MessageBox.Show("Please Select the Base Directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (output == "")
                MessageBox.Show("Please Select the Game Directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (SeedInput.Text == "")
                MessageBox.Show("Please Enter in a Seed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Options.CheckedItems.Count < 1)
                MessageBox.Show("Please Check an Option to Randomize!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                uint seed = 0;
                if (!uint.TryParse(SeedInput.Text, out seed))
                    seed = BKDR(SeedInput.Text);

                Core.Randomizer randomizer = new Core.Randomizer((int)seed, original, output, "Temp");

                foreach (var item in Options.CheckedItems)
                    randomizer.options[Options.Items.IndexOf(item)] = true;

                (bool, Exception) result = randomizer.Randomize();

                if (result.Item1)
                    MessageBox.Show("Successfully Randomized Game!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to Randomize Game: \n\n" + result.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}