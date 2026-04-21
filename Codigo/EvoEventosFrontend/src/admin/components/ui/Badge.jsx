export default function Badge({ tone = 'neutral', children }) {
  return <span className={`ad-badge ad-badge--${tone}`}>{children}</span>
}
