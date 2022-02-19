export function Price(props: { value: number, className?: string }) {
    return <span className={props.className}>
        {props.value.toLocaleString('en-US', {
            style: 'currency',
            currency: 'UAH',
        })}
    </span>
}

export function Icon(props: { name: string, size: number }) {
    const { name, size } = props;
    return <span className={`bi-${name}`} style={{ fontSize: size, lineHeight: 1 }}></span>
}