import { Spinner as BootstrapSpinner } from "react-bootstrap";

export const Spinner = () => {
    return <div className="d-flex justify-content-center">
        <BootstrapSpinner animation="border" variant="text-secondary" />
    </div>;
}