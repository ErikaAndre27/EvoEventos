export default function Card({ className = '', children }) {
  return <article className={`ad-card ${className}`.trim()}>{children}</article>
}
