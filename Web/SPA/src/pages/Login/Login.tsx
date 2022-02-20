import React from 'react'
import Login from '../../containers/Login'
import { types, useInjection } from '../../ioc'
// import LoginStore from '../../stores/LoginStore'
import { Button, ButtonGroup, Col, Container, Row } from 'react-bootstrap'
// import { Button, Container, Grid, Typography } from '@mui/material'
import { observer } from 'mobx-react-lite'
import { useNavigate } from 'react-router-dom'
import ownTypes from '../../ioc/ownTypes'
// import { User } from '../../models/User'
import { Icon } from '../../components/Utils'
import './Login.css'

const LoginPage = observer(() => {
  return null;
});
//   const store = useInjection<LoginStore>(ownTypes.loginStore);

//   return (
//     <Container>
//       {!!store.user
//         ? <Account />
//         : <Login />
//       }
//     </Container>
//   )
// })

// const Account = () => {
//   const store = useInjection<LoginStore>(ownTypes.loginStore);
//   const navigate = useNavigate()
//   const user = store.user!
//   return (
//     <div className="centered account">
//       <Icon name="person-check" size={150} />
//       <h6>
//         Logged as {user.firstName} {user.lastName} - <strong>{user.email}</strong>
//       </h6>
//       <div className="d-flex">
//         <Button variant="outline-secondary" onClick={() => navigate('/')}>
//           Go to Home
//         </Button>
//         <Button variant='outline-secondary' onClick={() => store.logOut()}>
//           Log out
//         </Button>
//       </div>
//     </div>
//   )
// }

export default LoginPage