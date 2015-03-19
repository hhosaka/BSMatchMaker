using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BSMatchMaker {
    [Serializable]
    public class Game {
		public bool IsThreePointMatch {
			get;
			private set;
		}
        private static Random rand = new Random();
        internal Stack<Round> Rounds = new Stack<Round>();

        public Player[] Players {
            get;
            private set;
        }

		public Player[] SortByRank {
			get { return Player.OrderByRank(Players); }
		}

		public Game() {
			this.Players = new Player[0];
		}
		
		public Game(Player[] players,bool IsThreePointMatch) {
            this.Players = players;
			this.IsThreePointMatch = IsThreePointMatch;
        }

        private static int randomswap(Player a, Player b) {
            return rand.Next(3)-1;
        }

        private static Player Confirm(Stack<Player> stack,Stack<Player> temp, Player player) {
            while (stack.Count() > 0) {
                var ret = stack.Pop();
                if (!ret.hasMatched(player)) {
                    return ret;
                } else {
                    temp.Push(ret);
                }
            }
            return null;
        }

        private static Player Confirm(Stack<Player> stack, Player player) {
            var temp = new Stack<Player>();
            var ret= Confirm(stack, temp, player);
            foreach(var p in temp){
                stack.Push(p);
            }
            return ret;
        }

        public bool Make(int count) {
            for(int i=0; i<count; ++i){
                if(Make()){
                    return true;
                }
            }
            return false; 
        }

        private bool Make() {
            Debug.Assert(Players != null);
            if (Rounds.Count>0 && LatestRound.Status == Match.STATUS.MATCHING) {
                Rounds.Pop();
            }
            int id = 0;
            var ret = new Round(Rounds.Count+1);
            Array.Sort(Players,randomswap);
            Array.Sort(Players, Player.comparison);
            var stack = new Stack<Player>();
            foreach (var player in Players) {
                if (!player.Dropped) {
                    if (stack.Count == 0) {
                    stack.Push(player);
                    } else {
                        Player p = Confirm(stack, player);
                        if (p != null) {
                            var m = new Match(++id, p, player);
                            ret.Add(m);
                        } else {
                            stack.Push(player);
                        }
                    }
                }
            }
            if (stack.Count > 0) {
                ret.Add(new Match(++id, stack.Pop(),IsThreePointMatch?2:1));
            }
            Rounds.Push(ret);
            return stack.Count==0;
        }

		internal Round LatestRound {
			get{
				Debug.Assert(Rounds.Count > 0);
				return Rounds.Peek();
			}
		}
		public void Reset() {
			if (Rounds.Count > 0) {
				if (Rounds.Peek().Status == Match.STATUS.MATCHING) {
					Rounds.Pop();
				}
			}
		}
		public void Bind(string filename) {
			LatestRound.bind();
			if (filename != null) {
				Game.Save(filename, this);
			}
		}
		public static bool Load(string filename, ref Game game) {
			IFormatter formatter = new BinaryFormatter();
			try {
				using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) {
					Properties.Settings.Default.currentFilename = filename;
					Properties.Settings.Default.Save();
					game = (Game)formatter.Deserialize(stream);
					//OnUpdate();
					return true;
				}
			} catch {
				return false;
			}
		}

		private bool Save(Game game) {
			return Save(Properties.Settings.Default.currentFilename, game);
		}

		public static bool Save(string filename, Game game) {
			IFormatter formatter = new BinaryFormatter();
			try {
				using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None)) {
					formatter.Serialize(stream, game);
					Properties.Settings.Default.currentFilename = filename;
					return true;
				}
			} catch {
				return false;
			}
		}
	}
}
