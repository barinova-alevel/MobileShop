import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { IoCProvider } from './ioc/ioc.react';
import { container } from './ioc/ioc';

ReactDOM.render(
  <React.StrictMode>
    <IoCProvider container={container}>
        <App/>
      </IoCProvider>
  </React.StrictMode>,
  document.getElementById('root')
);