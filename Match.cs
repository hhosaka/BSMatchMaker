using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSMatchMaker{
    [Serializable]
    public class Match {
		private const int MINIMUM_POINT = 1;
		private const int PLAYER1 = 0;
		private const int PLAYER2 = 1;
		private static readonly Player BYE = new Player(0, "BYE");
		private int[] points = new int[2];
		public Player[] players = new Player[2];

		public enum STATUS { UNDEF, MATCHING, PLAYING, DONE };

		public void Update(int player1_point, int player2_point) {
			points[PLAYER1] = player1_point;
			points[PLAYER2] = player2_point;
			Status = STATUS.DONE;
		}

		private Dictionary<Player,int>points2 = new Dictionary<Player,int>();
		public int id { get; private set; }

		public bool IsBYEGame {
			get {
				return players[PLAYER2]==BYE;
			}
		}

		public STATUS Status {
			get;
			private set;
		}

        internal Match(int id, Player player1, Player player2) {
			this.id = id;
			this.players[PLAYER1] = player1;
			this.players[PLAYER2] = player2;
			Status = STATUS.MATCHING;
        }

        internal Match(int id, Player player, int fullpoint) :this(id,player,BYE){
            this.points[0] = fullpoint;
			Status = STATUS.DONE;
		}

        private static int GetMatchPoint(int player, int opponent) {
            if (player > opponent) {
                return 3;
            } else if (player < opponent) {
                return 0;
            } else {
                return 1;
            }
        }

		public bool IsTarget(int player1_point, int player2_point) {
			return points[PLAYER1] == player1_point && points[PLAYER2] == player2_point;
		}

		private int MyIndex(Player player) {
			return this.players[PLAYER1] == player ? PLAYER1 : PLAYER2;
		}

		private int OpponentIndex(Player player) {
			return this.players[PLAYER1] == player ? PLAYER2 : PLAYER1;
		}

		private int GetMyPoint(Player player) {
			return this.points[MyIndex(player)];
		}

		public int GetOpponentMatchPoint(Player player) {
			return this.players[OpponentIndex(player)].MatchPoint;
		}

		private int GetOpponentPoint(Player player) {
			return this.points[OpponentIndex(player)];
		}

		public int GetMatchPoint(Player player) {
			return GetMatchPoint(GetMyPoint(player), GetOpponentPoint(player));
        }

        public int getWinPoint(Player player) {
			return GetMyPoint(player) - GetOpponentPoint(player);
        }

        internal void bind(int round) {
            foreach (var p in players) {
                p.Bind(this);
            }
			Status = IsBYEGame?STATUS.DONE:STATUS.PLAYING;
        }
    }
}
