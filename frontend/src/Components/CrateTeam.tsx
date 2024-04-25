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
    const [formData, setFormData] = useState({ name: "", city: "", attack: 5, defense: 5, midfield: 5});
    const [teamExist, setTeamExist] = useState(true);
    const [camp, setCamp] = useState(true);
    const [liga, setLiga] = useState(0);
    const [teamId, setTeamId] = useState(0);

    const checkTeam = async () => {
        const response = await requestData("/team");
        const regex = new RegExp(formData.name, "i");
        const teamExists = response.find((team: ITeam) => regex.test(team.name));
        const cityLength = formData.city.length >= 3;

        setTeamExist(!teamExists && cityLength);
    };
    
    useEffect(() => {
        checkTeam();
    }, [formData.name, formData.city, formData.attack, formData.midfield, formData.defense]);
    
    const pointsLeft = 15 - (formData.attack + formData.midfield + formData.defense);
    
    const createTeam = async () => {
        await sendData("/team", formData);
    };
    
    const checkIdTeam = async () => {
        const response = await requestData("/Team");
        const teamExists = response.find((team: ITeam) => team.name === formData.name).teamId;
        console.log(teamExists);
        setTeamId(teamExists);
    }

    const addCamp = async () => {
        await sendData("/TeamChampionshipLink", { ...formData, teamId: teamId, ChampionshipId: liga });
    }

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    return (
        <div className="create-team-container">
            {
                camp ? (
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
                                    value={formData.attack}
                                    onChange={(value) => setFormData({...formData, attack: value})}
                                    disabled={pointsLeft === 0}
                                />
                                <AttributeControl
                                    label="Meio campo"
                                    value={formData.midfield}
                                    onChange={(value) => setFormData({...formData, midfield: value})}
                                    disabled={pointsLeft === 0}
                                />
                                <AttributeControl
                                    label="Defesa"
                                    value={formData.defense}
                                    onChange={(value) => setFormData({...formData, defense: value})}
                                    disabled={pointsLeft === 0}
                                />
                            </div>
                        </div>
                        <div className="create-back">
                                <button
                                    className="button-creat-team" 
                                    disabled={!teamExist || pointsLeft !== 0}
                                    type="submit"
                                    onClick={() => { createTeam(); setCamp(false) }}
                                >
                                    Criar
                                </button>
                            <Link to="/">
                                <button className="button-creat-team">Voltar</button>
                            </Link>
                        </div>
                    </div>
                ) : (
                    <div className="Conteainer-liga">
                        <h1>Escolha a liga</h1>
                        <div className="liga">
                            <button onClick={() => { setLiga(1); checkIdTeam() }}>Carioca</button>
                            <button onClick={() => { setLiga(2); checkIdTeam() }}>Paulista</button>
                        </div>
                        <Link to="/championships">
                            <button
                                type="submit"
                                className="button-creat-team"
                                onClick={ addCamp }>Confirmar</button>
                        </Link>
                    </div>
                )
            }
        </div>
    );
};

export default CreateTeam;
