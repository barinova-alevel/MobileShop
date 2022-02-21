import { Container } from "inversify";
import ownTypes from "../../ioc/ownTypes";
import MobileService from "./services/MobileService";
import BrandsStore from "./stores/BrandStore";
import MobilesStore from "./stores/MobilesStore";
import MobileStore from "./stores/MobileStore";
import OSStore from "./stores/OSStore";

export function registerMobile(container: Container) {
    container.bind<MobileService>(ownTypes.mobileService).to(MobileService).inTransientScope();
    container.bind<MobileStore>(ownTypes.mobileStore).to(MobileStore).inTransientScope();
    container.bind<MobilesStore>(ownTypes.mobilesStore).to(MobilesStore).inSingletonScope();
    container.bind<BrandsStore>(ownTypes.mobileBrandsStore).to(BrandsStore).inTransientScope();
    container.bind<OSStore>(ownTypes.mobileOSStore).to(OSStore).inTransientScope();
}