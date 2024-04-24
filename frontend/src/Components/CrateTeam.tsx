import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { requestData, sendData } from "../Service/Request";

import "../style/createTeam.css"

interface ITeam {
    name: string;
}

const CreateTeam = () => {
    const [formData, setFormData] = useState({ name: "", city: "" });
    const [teamExist, setTeamExist] = useState(true);

    const checkTeam = async () => {
        // Supondo que requestData seja uma função que faz uma requisição
        const response = await requestData("/team");
        const regex = new RegExp(formData.name, "i");
        const teamExists = response.find((team: ITeam) => regex.test(team.name));
        const cityLength = formData.city.length >= 3;

        setTeamExist(!teamExists && cityLength);
    };

    useEffect(() => {
        checkTeam();
    }, [formData.name, formData.city]);

    const createTeam = async () => {
        // Supondo que sendData seja uma função que envia dados para o servidor
        await sendData("/team", formData);
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    return (
        <div className="create-team-container">
            <div className="form-container">
                <h1>Crie seu Time</h1>
                <input
                    type="text"
                    name="name"
                    value={formData.name}
                    onChange={handleInputChange}
                    placeholder="Nome da equipe"
                />
                <input
                    type="text"
                    name="city"
                    value={formData.city}
                    onChange={handleInputChange}
                    placeholder="Cidade"
                />
                <Link to="/championships">
                    <button
                        className="button-creat-team" 
                        disabled={!teamExist}
                        type="submit"
                        onClick={createTeam}
                    >
                        Criar
                    </button>
                </Link>
            </div>
        </div>
    );
};

export default CreateTeam;
