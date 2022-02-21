import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Callback, LogoutCallback, PrivateOutlet, SilentRenew } from "../../modules/auth/components";
import { Basket } from "../../modules/basket/components";
import { LaptopDetails, LaptopList } from "../../modules/laptop/components";
import { MobileDetails, MobileList } from "../../modules/mobile/components";
import Layout from "./Layout";

const AppRoutes = () => {
    return <BrowserRouter>
        <Routes>
            <Route path="/" element={<Layout />} >
                <Route path="" element={<MobileList />} />
                <Route path="mobile" element={<MobileList />} />
                <Route path="mobile/:id" element={<MobileDetails />} />
                <Route path="laptop" element={<LaptopList />} />
                <Route path="laptop/:id" element={<LaptopDetails />} />
                <Route path="/signin-oidc" element={<Callback />} />
                <Route path="/logout/callback" element={<LogoutCallback />} />
                <Route path="/silentrenew" element={<SilentRenew />} />
                <Route element={<PrivateOutlet />}>
                    <Route path="basket" element={<Basket />} />
                </Route>
            </Route>
        </Routes>
    </BrowserRouter>
}

export default AppRoutes;