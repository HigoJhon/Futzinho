import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { requestData, sendData } from "../Service/Request";

import "../style/createTeam.css";

interface ITeam {
    name: string;
}

interface AttributeProps {
    label: string;
    value: number;
    onChange: (value: number) => void;
    disabled: boolean;
}

const AttributeControl: React.FC<AttributeProps> = ({ label, value, onChange, disabled }) => (
    <div className="point">
        <h3>{label}</h3>
        <div className="point-buttons">
            <button onClick={() => onChange(value + 1)} disabled={disabled}>
                +
            </button>
            <span>{value}</span>
            <button onClick={() => onChange(value - 1)} disabled={value === 0}>
                -
            </button>
        </div>
    </div>
);

const CreateTeam = () => {
    const [formData, setFormData] = useState({ name: "", city: "" });
    const [teamExist, setTeamExist] = useState(true);
    const [attackPoints, setAttack] = useState(5);
    const [defensePoints, setDefense] = useState(5);
    const [midfieldPoints, setMidfield] = useState(5);

    const checkTeam = async () => {
        const response = await requestData("/team");
        const regex = new RegExp(formData.name, "i");
        const teamExists = response.find((team: ITeam) => regex.test(team.name));
        const cityLength = formData.city.length >= 3;

        setTeamExist(!teamExists && cityLength);
    };

    useEffect(() => {
        checkTeam();
    }, [formData.name, formData.city]);

    const pointsLeft = 15 - (attackPoints + defensePoints + midfieldPoints);

    const createTeam = async () => {
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
                <div className="input-container">
                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        onChange={handleInputChange}
                        placeholder="Nome da equipe"
                    />
                </div>
                <div className="input-container">
                    <input
                        type="text"
                        name="city"
                        value={formData.city}
                        onChange={handleInputChange}
                        placeholder="Cidade"
                    />
                </div>
                <div className="points-game">
                    <h2>Pontos restantes: {pointsLeft}</h2>

                    <div className="points">
                        <AttributeControl
                            label="Ataque"
                            value={attackPoints}
                            onChange={setAttack}
                            disabled={pointsLeft === 0}
                        />
                        <AttributeControl
                            label="Meio campo"
                            value={midfieldPoints}
                            onChange={setMidfield}
                            disabled={pointsLeft === 0}
                        />
                        <AttributeControl
                            label="Defesa"
                            value={defensePoints}
                            onChange={setDefense}
                            disabled={pointsLeft === 0}
                        />
                    </div>
                </div>
                <div className="create-back">
                    <Link to="/championships">
                        <button
                            className="button-creat-team" 
                            disabled={!teamExist || pointsLeft !== 0}
                            type="submit"
                            onClick={createTeam}
                        >
                            Criar
                        </button>
                    </Link>
                    <Link to="/">
                        <button className="button-creat-team">Voltar</button>
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default CreateTeam;
