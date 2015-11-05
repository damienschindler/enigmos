﻿using Cpln.Enigmos.Enigmas;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    class Enigma : Panel
    {
        private string id;
        private string strHint;
        private string strAnswer;
        private List<string> prerequisites = new List<string>();

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Hint
        {
            get
            {
                return strHint;
            }
        }

        public Enigma(EnigmaPanel enigmaPanel, string id, string hint, string answer)
        {
            this.id = id;
            this.strHint = hint;
            this.strAnswer = answer;

            TableLayoutPanel centerLayout = new TableLayoutPanel();
            centerLayout.ColumnCount = 3;
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerLayout.RowCount = 3;
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerLayout.Dock = DockStyle.Fill;

            Controls.Add(centerLayout);
            centerLayout.Controls.Add(enigmaPanel, 1, 1);

            Dock = DockStyle.Fill;
        }

        public Enigma(EnigmaPanel enigmaPanel, string id, string hint, string answer, string[] prerequisites)
            : this(enigmaPanel, id, hint, answer)
        {
            foreach (string prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
        }

        public bool CheckAnswer(string answer)
        {
            return answer == strAnswer;
        }

        public void AddPrerequisite(Enigma prerequisite)
        {
            prerequisites.Add(prerequisite.Id);
        }

        public bool IsPlayable(List<string> solved)
        {
            foreach (string prerequisite in prerequisites)
            {
                if (!solved.Contains(prerequisite))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
