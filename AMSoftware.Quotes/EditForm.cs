/*
Quotes Screensaver
Copyright (C) 2020 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Linq;
using System.Windows.Forms;

namespace AMSoftware.QuotesScreensaver
{
    public partial class EditForm : Form
    {
        private ListViewItem _activeListItem = null;

        public EditForm()
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} [{Application.ProductVersion}] - Editor";

            if (this.Parent != null)
            {
                this.Width = this.ParentForm.Width;
                this.Height = this.ParentForm.Height;
            }

            ResizeHeaders();
        }

        internal QuoteManager Manager { get; set; }

        private void EditForm_Shown(object sender, EventArgs e)
        {
            if (Manager == null) return;

            foreach (Quote item in Manager)
            {
                ListViewItem listItem = new ListViewItem(new string[] { string.Join(" ", item.QuoteText), item.Author, item.Source, item.Year })
                {
                    Tag = item
                };

                quotesListView.Items.Add(listItem);
            }

            quotesListView.Items.Add("New...");
        }

        private void EditForm_Resize(object sender, EventArgs e)
        {
            ResizeHeaders();
        }

        private void ResizeHeaders()
        {
            quoteColumnHeader.Width = (int)Math.Round(quotesListView.Width * 0.5);
            authorColumnHeader.Width = (int)Math.Round(quotesListView.Width * 0.2);
            sourceColumnHeader.Width = (int)Math.Round(quotesListView.Width * 0.2);
            yearColumnHeader.Width = (int)Math.Round(quotesListView.Width * 0.1);
        }

        private void QuotesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quotesListView.SelectedItems.Count != 1)
            {
                _activeListItem = null;
                return;
            }
            _activeListItem = quotesListView.SelectedItems[0];

            if (_activeListItem.Tag == null)
            {
                quoteTextBox.Lines = new string[] { };
                authorTextBox.Text = string.Empty;
                sourceTextBox.Text = string.Empty;
                yearTextBox.Text = string.Empty;
            }
            else
            {
                Quote item = (Quote)_activeListItem.Tag;

                quoteTextBox.Lines = item.QuoteText;
                authorTextBox.Text = item.Author;
                sourceTextBox.Text = item.Source;
                yearTextBox.Text = item.Year;
            }

            foreach (Control control in detailsGroupBox.Controls)
            {
                control.Enabled = (_activeListItem != null);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_activeListItem != null)
            {
                Quote newQuote = new Quote()
                {
                    QuoteText = quoteTextBox.Lines,
                    Author = authorTextBox.Text,
                    Source = sourceTextBox.Text,
                    Year = yearTextBox.Text
                };

                if (_activeListItem.Tag == null)
                {
                    ListViewItem newListItem = new ListViewItem(new string[] { string.Join(" ", newQuote.QuoteText), newQuote.Author, newQuote.Source, newQuote.Year })
                    {
                        Tag = newQuote
                    };

                    int insertIndex = quotesListView.Items.Count - 1;
                    if (insertIndex < 0) insertIndex = 0;

                    quotesListView.Items.Insert(insertIndex, newListItem);

                    quotesListView.Items[insertIndex].Selected = true;
                }
                else
                {
                    _activeListItem.Tag = newQuote;
                    _activeListItem.SubItems[0].Text = string.Join(" ", newQuote.QuoteText);
                    _activeListItem.SubItems[1].Text = newQuote.Author;
                    _activeListItem.SubItems[2].Text = newQuote.Source;
                    _activeListItem.SubItems[3].Text = newQuote.Year;

                    _activeListItem.Selected = true;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Quotes qs = new Quotes();
            qs.AddRange(quotesListView.Items
                .Cast<ListViewItem>()
                .Where(item => item.Tag != null)
                .Select(item => item.Tag)
                .Cast<Quote>());

            Manager.WriteToFile(qs);
        }
    }
}
