const Icon = (props: { name: string, size: number }) => {
    const { name, size } = props;
    return <span className={`bi-${name}`} style={{ fontSize: size, lineHeight: 1 }}></span>
}

export default Icon;