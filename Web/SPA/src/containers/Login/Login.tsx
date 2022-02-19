import { observer } from 'mobx-react-lite';
import React, { useState } from 'react'
import { Button, Col, Container, Form, Row, Spinner } from 'react-bootstrap'
import { useInjection } from '../../ioc/ioc.react';
import ownTypes from '../../ioc/ownTypes';
import LoginStore from '../../stores/LoginStore';
import { useTranslation } from 'react-i18next';
import './Login.css'
import { Icon } from '../../components/Utils';

const Login = observer(() => {
  const store = useInjection<LoginStore>(ownTypes.loginStore);
  const { t } = useTranslation(['login']);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  return (
    <div className='text-center'>
      <Form
        className="form-signin"
        onSubmit={(ev) => {
          ev.preventDefault();
          store.login(email, password);
        }}>
        <Icon name="person" size={150} />
        <h1 className="h3 mb-3 font-weight-normal">{t('signInText')}</h1>
        <Form.Control
          type="email"
          placeholder={t('placeholder.email')}
          value={email}
          onChange={(ev) => { setEmail(ev.target.value) }}
        />
        <Form.Control
          type="password"
          placeholder={t('placeholder.password')}
          value={password}
          onChange={(ev) => { setPassword(ev.target.value) }}
        />
        {!!store.error && <p className='error'>{store.error}</p>}
        <Button className="btn btn-lg btn-block" type="submit">
          {store.isLoading ? (
            <Spinner animation="border" size="sm" />
          ) : (
            `${t('submit')}`
          )}
        </Button>
      </Form>
    </div>
  )
});

export default Login
