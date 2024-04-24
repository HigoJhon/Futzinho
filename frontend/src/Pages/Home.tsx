import { Link } from "react-router-dom";
import "../style/home.css";

const Home = () => {
  return (
    <main className="home">
      <div className="center-content">
        <form className="button-options">
          <h1>Fotzinho</h1>
          <Link className="link" to={"/in-game"}>
            <button>Continuar Game</button>
          </Link>
          <Link className="link" to="/newteam">
            <button>Criar Time</button>
          </Link>
        </form>
        <div className="info">
          <p>
            Um jogo onde vc pode criar seu time e disputar campeonatos
            incriveis, contra times fortes e poder melhorar seu time e chegar
            Top
          </p>
        </div>
      </div>
    </main>
  );
};

export default Home;
