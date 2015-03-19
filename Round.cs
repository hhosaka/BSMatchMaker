using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSMatchMaker {
    [Serializable]
    class Round : List<Match> {
        public static string ConvertString(int num) {
            switch (num) {
                case 1:
                    return "first";
                case 2:
                    return "second";
                case 3:
                    return "third";
                default:
                    return num + "th";
            }
        }

        public int ID {
            get;
            private set;
        }

		public string Title {
            get {
                return "The " + ConvertString(ID) + " Round "+statustitle(Status);
            }
        }

		public Round(int round) {
            this.ID = round;
        }

		private static string statustitle(Match.STATUS status ) {
			switch (status) {
				case Match.STATUS.DONE:
					return "Reviewing";
				case Match.STATUS.MATCHING:
					return "Matching";
				case Match.STATUS.PLAYING:
					return "Playing";
				case Match.STATUS.UNDEF:
					return "Undefined";
				default:
					throw new NotImplementedException();
			}
		}

		public Match.STATUS Status {
            get {
				if (Count == 0) {
					return Match.STATUS.UNDEF;
				} else {
					foreach (var match in this) {
						switch (match.Status) {
							case Match.STATUS.MATCHING:
							case Match.STATUS.PLAYING:
								return match.Status;
						}
					}
					return Match.STATUS.DONE;
				}
            }
        }

        public void bind() {
            Debug.Assert(Status == Match.STATUS.MATCHING);
            foreach (var match in this) {
                match.bind(ID);
            }
        }
    }
}
