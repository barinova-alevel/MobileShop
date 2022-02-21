const Price = (props: { value: number, className?: string }) => {
    return <span className={props.className}>
        {props.value.toLocaleString('en-US', {
            style: 'currency',
            currency: 'UAH',
        })}
    </span>
}

export default Price;