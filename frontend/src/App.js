import React from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import CoursesPage from './pages/CoursesPage';
import TeachersPage from './pages/TeachersPage';
import ParticipantsPage from './pages/ParticipantsPage';
import SessionsPage from './pages/SessionsPage';

function App() {
  return (
    <BrowserRouter>
      <div>
        <nav>
          <Link to="/">Hem</Link> |{' '}
          <Link to="/courses">Kurser</Link> |{' '}
          <Link to="/teachers">Lärare</Link> |{' '}
          <Link to="/participants">Deltagare</Link> |{' '}
          <Link to="/sessions">Sessioner</Link>
        </nav>

        <Routes>
          <Route path="/" element={<h1>Välkommen till Education System</h1>} />
          <Route path="/courses" element={<CoursesPage />} />
          <Route path="/teachers" element={<TeachersPage />} />
          <Route path="/participants" element={<ParticipantsPage />} />
          <Route path="/sessions" element={<SessionsPage />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;