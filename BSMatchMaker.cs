using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BSMatchMaker {
    class BSMatchMaker {
        private string defaultfilename=null;
		public event Action OnUpdate;
		private Game game;
        public Game Game {
            get {
                return game;
            }
            set {
                game = value;
                OnUpdate();
            }
        }
        private int cur;
		public bool IsMakeAvailable {
			get{
				if (Game == null) {
					return false;
				}else{
					switch (Game.Status) {
						case Match.STATUS.DONE:
						case Match.STATUS.UNDEF:
							return true;
						default:
							return false;
					}
				}
			}
		}

		public bool HasPrev {
            get { return cur > 0; }
        }
        public bool IsLast {
            get { return cur >= game.Rounds.Count - 1; }
        }
        public Round CurrentRound {
            get {
                if (game==null || game.Rounds.Count == 0) {
                    return null;
                } else {
					return game.Rounds.ElementAt(game.Rounds.Count - cur - 1);
                }
            }
        }
        public int Count {
            get {
                return cur;
            }
        }

		public bool IsMatchAvailable {
			get {
				return game.Players != null && game.Players.Length > 0;
			}
		}
        public Match.STATUS Status {
            get {
                return CurrentRound.Status;
            }
        }

        public bool Prev() {
            if (cur > 0) {
                --cur;
                OnUpdate();
                return true;
            }
            return false;
        }

        public bool Next() {
            if (cur < game.Rounds.Count - 1) {
                ++cur;
                OnUpdate();
                return true;
            } else {
                if (game.AppendMatch()) {
                    cur = game.Rounds.Count - 1;
                    OnUpdate();
                    return true;
                } else {
                    return false;
                }
            }
        }

        public void Reset(){
			if (game.Rounds.Peek().Status == Match.STATUS.MATCHING) {
				game.Rounds.Pop();
				OnUpdate();
			}
        }

		public void DoUpdate() {
			OnUpdate();
		}

		public bool Load() {
            return Load(defaultfilename);
        }

        public bool Load(string filename) {
            IFormatter formatter = new BinaryFormatter();
            try{
                using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None)) {
                    defaultfilename = filename;
                    Game = (Game)formatter.Deserialize(stream);
                    OnUpdate();
                    return true;
                }
            }catch{
                return false;
            }
        }

        private void Save() {
            Save(defaultfilename);
        }

        public void Save(string filename) {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None)) {
                formatter.Serialize(stream, game);
                defaultfilename = filename;
            }
        }
        public void Bind(){
            game.LatestRound.bind();
            if (defaultfilename != null) {// TODO
                Save(defaultfilename);
            }
            OnUpdate();
        }
    }
}
