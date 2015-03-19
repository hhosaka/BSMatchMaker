using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BSMatchMaker {
    class GameNavigator {
		private const int MAX_MATCHING_TRY_COUNT = 10;
		private readonly Round undef = new Round(0);
		public event Action OnUpdate;
		public readonly Game game;
		private int cur;

		public GameNavigator(Game game) {
			this.game = game;
			if (game.Rounds.Count == 0) {
				game.Make(MAX_MATCHING_TRY_COUNT);
			}
			cur = game.Rounds.Count - 1;
		}

		public bool HasPrev {
            get { return cur > 0; }
        }
        public bool HasNext {
            get { return cur < game.Rounds.Count-1; }
        }

		public Round Current {
            get {
                if (game.Rounds.Count == 0) {
                    return undef;
                } else {
					return game.Rounds.ElementAt(game.Rounds.Count - cur - 1);
                }
            }
        }

        public bool Prev() {
            if (HasPrev) {
                --cur;
                OnUpdate();
                return true;
            }
            return false;
        }

        public bool Next() {
            if (HasNext) {
                ++cur;
                OnUpdate();
                return true;
            } else {
				if (game.Make(MAX_MATCHING_TRY_COUNT)) {
                    cur = game.Rounds.Count - 1;
                    OnUpdate();
                    return true;
                } else {
                    return false;
                }
            }
        }
    }
}
