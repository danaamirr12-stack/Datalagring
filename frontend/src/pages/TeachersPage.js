import React, { useState, useEffect } from 'react';
import { teacherService } from '../services/api';

function TeachersPage() {
  const [teachers, setTeachers] = useState([]);
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');

  useEffect(() => {
    teacherService.getAll().then(function(res) {
      setTeachers(res.data);
    });
  }, []);

  function addTeacher() {
    teacherService.create({ firstName: firstName, lastName: lastName, email: email }).then(function() {
      setFirstName('');
      setLastName('');
      setEmail('');
      teacherService.getAll().then(function(res) {
        setTeachers(res.data);
      });
    });
  }

  function removeTeacher(id) {
    teacherService.delete(id).then(function() {
      teacherService.getAll().then(function(res) {
        setTeachers(res.data);
      });
    });
  }

  return (
    <div>
      <h2>Lärare</h2>
      <input value={firstName} onChange={function(e) { setFirstName(e.target.value); }} placeholder="Förnamn" />
      <input value={lastName} onChange={function(e) { setLastName(e.target.value); }} placeholder="Efternamn" />
      <input value={email} onChange={function(e) { setEmail(e.target.value); }} placeholder="Email" />
      <button onClick={addTeacher}>Lägg till</button>
      <ul>
        {teachers.map(function(teacher) {
          return (
            <li key={teacher.id}>
              {teacher.firstName} {teacher.lastName} - {teacher.email}
              <button onClick={function() { removeTeacher(teacher.id); }}>Ta bort</button>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default TeachersPage;