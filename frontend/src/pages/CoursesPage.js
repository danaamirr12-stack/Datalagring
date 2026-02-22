import React, { useState, useEffect } from 'react';
import { courseService } from '../services/api';

function CoursesPage() {
  const [courses, setCourses] = useState([]);
  const [name, setName] = useState('');
  const [courseDescription, setCourseDescription] = useState('');
  const [weeksDuration, setWeeksDuration] = useState('');

  useEffect(() => {
    courseService.getAll().then(function(res) {
      setCourses(res.data);
    });
  }, []);

  function addCourse() {
    courseService.create({ name: name, courseDescription: courseDescription, weeksDuration: parseInt(weeksDuration) }).then(function() {
      setName('');
      setCourseDescription('');
      setWeeksDuration('');
      courseService.getAll().then(function(res) {
        setCourses(res.data);
      });
    });
  }

  function removeCourse(id) {
    courseService.delete(id).then(function() {
      courseService.getAll().then(function(res) {
        setCourses(res.data);
      });
    });
  }

  return (
    <div>
      <h2>Kurser</h2>
      <input value={name} onChange={function(e) { setName(e.target.value); }} placeholder="Namn" />
      <input value={courseDescription} onChange={function(e) { setCourseDescription(e.target.value); }} placeholder="Beskrivning" />
      <input value={weeksDuration} onChange={function(e) { setWeeksDuration(e.target.value); }} placeholder="Antal veckor" type="number" />
      <button onClick={addCourse}>Lägg till</button>
      <ul>
        {courses.map(function(course) {
          return (
            <li key={course.id}>
              {course.name} - {course.courseDescription} - {course.weeksDuration} veckor
              <button onClick={function() { removeCourse(course.id); }}>Ta bort</button>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default CoursesPage;