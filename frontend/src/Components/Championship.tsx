import { useEffect, useState } from "react";
import { requestData } from "../Service/Request";
import "../style/Championship.css";

interface ITeam {
    id: number;
    name: string;
    teams: string[];
}

const Championship = () => {
    const [championships, setChampionships] = useState<ITeam[]>([]);

    const fetchChampionships = async () => {
        const teamsData = await requestData("/championship");
        setChampionships(teamsData);
    }
    
    useEffect(() => {
        fetchChampionships();
    }, []);

    return (
        <section className="section-team">
            <h1>Tabelas dos campeonatos</h1>
            <table>
                <thead>
                    <tr>
                        {championships.map((team: ITeam) => (
                            <th key={team.id}>{team.name}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {championships.map((team: ITeam) => (
                        <tr key={team.id} className="table-teams">
                            {team.teams.map((teamName: string, index) => (
                                <td key={index}>{teamName}</td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </table>
        </section>
    );
}

export default Championship;
