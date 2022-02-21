import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap-icons/font/bootstrap-icons.css";
import './App.css'
import '../../locales/config';
import { useEffect } from 'react';
import { types, useInjection } from '../../ioc';
import { AuthStore } from '../../modules/auth/AuthStore';
import BasketStore from '../../modules/basket/BasketStore';
import AppRoutes from './AppRoutes';

function App() {
  const loginStore = useInjection<AuthStore>(types.authStore);
  const basketStore = useInjection<BasketStore>(types.basketStore);

  useEffect(() => {
    async function restore() {
      await loginStore.getUser();
      if (loginStore.isUserLoggedIn) {
        await basketStore.getBasket();
      }
    }

    restore();
  }, [])

  return <AppRoutes />;
}

export default App;
