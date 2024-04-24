import { useState } from "react";
import { sendData } from "../Service/Request"

const CreateTeam = () => {
    const [name, setName] = useState("");
    const [city, setCity] = useState("");

    const createTeam = async () => {
        await sendData("/team", { name, city });
    }

    return (
        <div>
            <h1>Create Team</h1>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>City</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><input type="text" name="name" id="name" value={ name }  onChange={({ target: { value } }) => setName(value)}/></td>
                        <td><input type="text" name="city" id="city" value={ city } onChange={({ target: { value } }) => setCity(value)}/></td>
                    </tr>
                </tbody>
                <button 
                    type="submit"
                    onClick={createTeam}
                >Criar</button>
            </table>
        </div>
    );
};

export default CreateTeam;