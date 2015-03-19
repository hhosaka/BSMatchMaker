using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSMatchMaker {
    [Serializable]
    public class Player {
		private List<Match> matches = new List<Match>();
        public bool Dropped;
        public int id { get; private set; }
		public int rank{ get; private set;}
        public string name { get; private set; }

		public float GetMatchResult(Boolean showPercentage) {
			if (showPercentage) {
				return MatchPercentage;
			} else {
				return MatchPoint;
			}
		}

		private float MatchPercentage {
			get {
				if (matches.Count == 0) {
					return 0;
				} else {
					return (float)MatchPoint / (matches.Count * 3);
				}
			}
		}

		public int MatchPoint {
            get {
                int ret = 0;
                foreach (var match in matches) {
                    ret += match.GetMatchPoint(this);
                }
                return ret;
            }
        }

		public int WinPoint {
            get {
                int ret = 0;
                foreach (var match in matches) {
                    ret += match.getWinPoint(this);
                }
                return ret;
            }
        }

		public float OpponentPercentage {
			get {
				if (matches.Count == 0) {
					return 0;
				} else {
					return OpponentPoint / (matches.Count * 3);
				}
			}
		}

		public float OpponentPoint {
            get {
                float ret = 0;
				int count = 0;
                foreach (var match in matches) {
					if (!match.IsBYEGame) {
						++count;
						ret += match.GetOpponentMatchPoint(this);
					}
                }
				if (count == 0) {
					return 0;
				} else {
                    return ret / count;
                }
            }
        }

        internal Player(int id, string name) {
            this.id = id;
            this.name = name;
        }

//        internal int MatchCount { get { return matches.Count; } }
        internal void Bind(Match match)
		{
			matches.Add(match); 
		}

		internal bool hasMatched(Player opponent) {
            foreach (var match in matches) {
                foreach(var p in match.players){
                    if (p == opponent) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int comparison(Player a, Player b) {
            int ret;
            float fret;
            if ((ret = b.MatchPoint - a.MatchPoint) != 0) {
                return ret;
            } else if ((fret = b.OpponentPoint - a.OpponentPoint) != 0.0) {
                return fret > 0.0 ? 1 : -1;
            } else if ((ret = b.WinPoint - a.WinPoint) != 0) {
                return ret;
            } else {
                return 0;
            }
        }

        public static int comparison_with_id(Player a, Player b) {
            int ret;
            if ((ret = comparison(a, b)) != 0) {
                return ret;
            } else {
                return a.id - b.id;
            }
        }

		public static Player[] OrderByRank(Player[] players) {
			int rank = 0;
			int i = 0;
			Player prev = null;

			Array.Sort(players, comparison_with_id);
			foreach (var player in players) {
				++i;
				if (prev == null || comparison(prev, player) != 0) {
					rank = i;
				}
				player.rank = rank;
				prev = player;
			}
			return players;
		}
    }
}
