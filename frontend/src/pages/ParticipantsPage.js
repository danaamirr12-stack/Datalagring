import React, { useState, useEffect } from 'react';
import { participantService } from '../services/api';

function ParticipantsPage() {
  const [participants, setParticipants] = useState([]);
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');

  useEffect(() => {
    participantService.getAll().then(function(res) {
      setParticipants(res.data);
    });
  }, []);

  function addParticipant() {
    participantService.create({ firstName: firstName, lastName: lastName, phone: phone, email: email }).then(function() {
      setFirstName('');
      setLastName('');
      setPhone('');
      setEmail('');
      participantService.getAll().then(function(res) {
        setParticipants(res.data);
      });
    });
  }

  function removeParticipant(id) {
    participantService.delete(id).then(function() {
      participantService.getAll().then(function(res) {
        setParticipants(res.data);
      });
    });
  }

  return (
    <div>
      <h2>Deltagare</h2>
      <input value={firstName} onChange={function(e) { setFirstName(e.target.value); }} placeholder="Förnamn" />
      <input value={lastName} onChange={function(e) { setLastName(e.target.value); }} placeholder="Efternamn" />
      <input value={phone} onChange={function(e) { setPhone(e.target.value); }} placeholder="Telefon" />
      <input value={email} onChange={function(e) { setEmail(e.target.value); }} placeholder="Email" />
      <button onClick={addParticipant}>Lägg till</button>
      <ul>
        {participants.map(function(participant) {
          return (
            <li key={participant.id}>
              {participant.firstName} {participant.lastName} - {participant.phone} - {participant.email}
              <button onClick={function() { removeParticipant(participant.id); }}>Ta bort</button>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default ParticipantsPage;