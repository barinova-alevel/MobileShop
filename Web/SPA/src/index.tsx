import React from 'react';
import ReactDOM from 'react-dom';
import { IoCProvider } from './ioc/ioc.react';
import { container } from './ioc/ioc';
import App from './components/App/App';

ReactDOM.render(
  <React.StrictMode>
    <IoCProvider container={container}>
        <App/>
      </IoCProvider>
  </React.StrictMode>,
  document.getElementById('root')
);