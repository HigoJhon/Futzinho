import { Route, Routes } from "react-router-dom"
import Home from "./Pages/Home"
import NewTeam from "./Pages/NewTeam"
import Championship from "./Components/Championship"

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/championships" element={<Championship />} />
      <Route path="/newTeam" element={<NewTeam />} />
    </Routes>
  )
}

export default App
