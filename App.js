import { createContext, useContext, useEffect, useState } from 'react';
import './App.css';
import Form from './Components/Form';
import Form_2 from './Components/Form_2';
import Table from './Components/Table';
import Table_2 from './Components/Table_2';
// import Table from './Components/Table';

function App() {

  // const [studentList, setStudentList] = useState([]);

  const [state, setState] = useState(1);

  const [name, setName] = useState("");

  const [gender, setGender] = useState([]);
  const [genderID, setGenderID] = useState();

  const [subject, setSubject] = useState([]);
  const [subjectID, setSubjectID] = useState();

  

  const [userInfo, setUserInfo] = useState({
    name: "",
    gender_id: "",
    subject_id: ""
  });


  useEffect(()=>{
    fetch('http://localhost:5000/student/getallgender')
    .then(response => response.json())
    .then(data => {
      // debugger;
      setGender(data)
    })
  }, []);


  useEffect(()=>{
    fetch('http://localhost:5000/student/getallsubject')
    .then(response => response.json())
    .then(data => {
      // debugger;
        setSubject(data)
      })
  }, []);

  
  // useEffect(()=>{
  //   fetch('http://localhost:5000/student/getallstudent')
  //   .then(response => response.json())
  //   .then(data => {
  //     // debugger;
  //       setStudentList(p=>(p = [...data]))
  //       })
  //     });
  
  // const nameHandler = (e)=>{
  //   var nameInput = e.target.value;
  //   setName(nameInput);
  // }

//   const userInfoSetter = ()=>{
//     setUserInfo({
//       id:1,
//       name: name
//     })
//   }

// const saveInfo = ()=>{
//     fetch('http://localhost:5000/student/create', {
//         method: 'POST',
//         headers: {
//         'Accept': 'application/json',
//         'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(userInfo)
//     }).then(res=>res.json())
//     .then(data=>{
//         console.log(data)
//     });
//   }

const nameHandler = (e)=>{
  var value = e.target.value;
  setName(value);
}

const genderHandler = (e)=>{
  var value = e.target.value;
  setGenderID(value);
}

const subjectHandler = (e)=>{
  var value = e.target.value;
  setSubjectID(value);
}

  

const saveData = ()=>{

  var data={
    name: name,
    subject_id: parseInt(subjectID),
    gender_id: parseInt(genderID)
  };

  if(name.length <= 0) return;
  if(!subjectID) return;
  if(!genderID)return;
  
      fetch('http://localhost:5000/student/create', {
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(res=>res.json())
    .then(data=>{
        console.log(data)
    });

    // console.log(userInfo);
}


const switchState = ()=>{
  state==1?setState(2):setState(1);
}


  return (
    <shareData.Provider value={{
        name: name,
        setName: setName,
        gender: gender,
        setGender: setGender,
        subject: subject,
        setSubject: setSubject,
        nameHandler: nameHandler,
        genderHandler: genderHandler,
        subjectHandler: subjectHandler,
        saveData: saveData
      }
    }>
      <div className="App">
        <button onClick={switchState}>Table</button>
        <button onClick={switchState}>Form</button>
        {state==1?<Table_2 />: <Form_2 />}
        
      </div>
    </shareData.Provider>
  );
}

export default App;
export const shareData = createContext();

