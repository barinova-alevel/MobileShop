import { useCallback } from "react";

type DropdownProps = {
    text: string;
    selectedId?: number;
    items: { id: number, name: string }[];
    onChange: (id?: number) => void;
}

export const Dropdown = (props: DropdownProps) => {
    const onChange = useCallback(_ => props.onChange(+_.target.value), []);
    return <select value={props.selectedId} className="form-select" onChange={onChange}>
        <option value={undefined}>{props.text}</option>
        {
            props.items?.map(_ => <option value={_.id} key={_.id}>{_.name}</option>)
        }
    </select>
}