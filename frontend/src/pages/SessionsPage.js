import React, { useState, useEffect } from 'react';
import { sessionService } from '../services/api';

function SessionsPage() {
  const [sessions, setSessions] = useState([]);
  const [title, setTitle] = useState('');
  const [date, setDate] = useState('');

  useEffect(() => {
    sessionService.getAll().then(function(res) {
      setSessions(res.data);
    });
  }, []);

  function addSession() {
    sessionService.create({ title: title, date: date }).then(function() {
      setTitle('');
      setDate('');
      sessionService.getAll().then(function(res) {
        setSessions(res.data);
      });
    });
  }

  function removeSession(id) {
    sessionService.delete(id).then(function() {
      sessionService.getAll().then(function(res) {
        setSessions(res.data);
      });
    });
  }

  return (
    <div>
      <h2>Sessioner</h2>
      <input value={title} onChange={function(e) { setTitle(e.target.value); }} placeholder="Titel" />
      <input value={date} onChange={function(e) { setDate(e.target.value); }} placeholder="Datum" type="date" />
      <button onClick={addSession}>Lägg till</button>
      <ul>
        {sessions.map(function(session) {
          return (
            <li key={session.id}>
              {session.title} - {session.date}
              <button onClick={function() { removeSession(session.id); }}>Ta bort</button>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default SessionsPage;